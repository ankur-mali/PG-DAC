package com.vca.app.controllers;

import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.handlers.ResponseHandler;

@CrossOrigin(origins = "*")
@RestController
public class HomeController {

	@GetMapping("/")
	public ResponseEntity<Object> Get() {
		try {
			Map<String, Object> responseData = new HashMap<>();
			responseData.put("currentTime", LocalDateTime.now());
			return ResponseHandler.apiResponse("Successfully retrieved data!", HttpStatus.OK, responseData);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.MULTI_STATUS, null);
		}
	}
}