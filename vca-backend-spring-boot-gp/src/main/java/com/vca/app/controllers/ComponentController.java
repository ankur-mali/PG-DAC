package com.vca.app.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.entity.Component;
import com.vca.app.repositories.ComponentRepository;

@CrossOrigin(origins = "*")
@RestController
public class ComponentController {

	@Autowired
	ComponentRepository repository;

	@GetMapping("/components")
	public ResponseEntity<List<Component>> getAllComponentById() {
		List<Component> components = repository.findAll();

//	    if (components.isEmpty()) {
//	        throw new ResourceNotFoundException("No data found");
//	    }
	    
		return new ResponseEntity<>(components, HttpStatus.OK);
	}

}
