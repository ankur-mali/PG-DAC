package com.vca.app.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.services.AlternateComponentService;
import com.vca.handlers.ResponseHandler;

@RestController
@CrossOrigin("*")
public class AlternateComponentController {

	@Autowired
	AlternateComponentService service;

	@GetMapping(value = "api/alternate-components/{modId}/{compId}")
	public ResponseEntity<Object> showStdComponents(@PathVariable(value = "modId") int mod_id,
			@PathVariable(value = "compId") int com_id) {
		List<?> data = service.findByModelIdAndCompId(mod_id, com_id);
		return ResponseHandler.apiResponse("Models retrieved successfully", HttpStatus.OK, data);
	}

}