package com.vca.springjwt.controllers;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.handlers.ResponseHandler;
import com.vca.springjwt.models.ERole;
import com.vca.springjwt.models.Role;
import com.vca.springjwt.models.User;
import com.vca.springjwt.payload.request.LoginRequest;
import com.vca.springjwt.payload.request.SignupRequest;
import com.vca.springjwt.repository.RoleRepository;
import com.vca.springjwt.repository.UserRepository;
import com.vca.springjwt.security.jwt.JwtUtils;
import com.vca.springjwt.security.services.UserDetailsImpl;

import jakarta.validation.Valid;

@CrossOrigin(origins = "*", maxAge = 3600)
@RestController
@RequestMapping("/api/auth")
public class AuthController {
	@Autowired
	AuthenticationManager authenticationManager;

	@Autowired
	UserRepository userRepository;

	@Autowired
	RoleRepository roleRepository;

	@Autowired
	PasswordEncoder encoder;

	@Autowired
	JwtUtils jwtUtils;

	@PostMapping("/signin")
	public ResponseEntity<Object> authenticateUser(@Valid @RequestBody LoginRequest loginRequest) {

		Authentication authentication = authenticationManager.authenticate(
				new UsernamePasswordAuthenticationToken(loginRequest.getUsername(), loginRequest.getPassword()));

		SecurityContextHolder.getContext().setAuthentication(authentication);
		String jwt = jwtUtils.generateJwtToken(authentication);

		UserDetailsImpl userDetails = (UserDetailsImpl) authentication.getPrincipal();
		List<String> roles = userDetails.getAuthorities().stream().map(item -> item.getAuthority())
				.collect(Collectors.toList());

		Map<String, Object> response = new HashMap<>();
		response.put("jwt", jwt);
		response.put("id", userDetails.getId());
		response.put("username", userDetails.getUsername());
		response.put("email", userDetails.getEmail());
		response.put("roles", roles);

		return ResponseHandler.apiResponse("logged in successfull!", HttpStatus.OK, response);
	}

	
	@PostMapping("/signup")
	public ResponseEntity<?> registerUser(@Valid @RequestBody SignupRequest signUpRequest) {
		if (userRepository.existsByUsername(signUpRequest.getUsername())) {
			
			Map<String, Object> response = new HashMap<>();
			response.put("error", "Username is already taken!");
			return ResponseHandler.apiResponse("Validation failed!", HttpStatus.BAD_REQUEST, response);
		}

		if (userRepository.existsByEmail(signUpRequest.getEmail())) {
			
			Map<String, Object> response = new HashMap<>();
			response.put("error", "Email is already in use!");
			return ResponseHandler.apiResponse("Validation failed!", HttpStatus.BAD_REQUEST, response);
		}

		// Create new user's account
		User user = new User(signUpRequest.getUsername(),
				signUpRequest.getEmail(),
				encoder.encode(signUpRequest.getPassword()),
				signUpRequest.getCompanyName(),
				signUpRequest.getAddressLine1(),
				signUpRequest.getAddressLine2(),
				signUpRequest.getCity(),
				signUpRequest.getState(),
				signUpRequest.getPinCode(),
				signUpRequest.getTelephone(),
				signUpRequest.getGstNumber());
		

		Set<String> strRoles = signUpRequest.getRole();
		Set<Role> roles = new HashSet<>();

		if (strRoles == null) {
			Role userRole = roleRepository.findByName(ERole.ROLE_USER)
					.orElseThrow(() -> new RuntimeException("Error: Role is not found."));
			roles.add(userRole);
		} else {
			strRoles.forEach(role -> {
				switch (role) {
				case "admin":
					Role adminRole = roleRepository.findByName(ERole.ROLE_ADMIN)
							.orElseThrow(() -> new RuntimeException("Error: Role is not found."));
					roles.add(adminRole);

					break;
				case "mod":
					Role modRole = roleRepository.findByName(ERole.ROLE_MODERATOR)
							.orElseThrow(() -> new RuntimeException("Error: Role is not found."));
					roles.add(modRole);

					break;
				default:
					Role userRole = roleRepository.findByName(ERole.ROLE_USER)
							.orElseThrow(() -> new RuntimeException("Error: Role is not found."));
					roles.add(userRole);
				}
			});
		}

		user.setRoles(roles);
		userRepository.save(user);

		return ResponseHandler.apiResponse("User registered successfully!", HttpStatus.OK, null);
	}
	
	@GetMapping(value = "/user/{user_id}")
	public ResponseEntity<Object> getVehicleByID(@PathVariable Long user_id) {

		try {
			 List<Map<String, Object>> data = userRepository.findByUserId(user_id);
			return ResponseHandler.apiResponse("User data", HttpStatus.OK, data);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}
}
