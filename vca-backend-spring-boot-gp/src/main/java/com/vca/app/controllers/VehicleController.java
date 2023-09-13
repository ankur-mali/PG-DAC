package com.vca.app.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.services.VehicleService;
import com.vca.handlers.ResponseHandler;


@RestController
@CrossOrigin(origins = "*")
@RequestMapping("/api")
public class VehicleController {
	
	@Autowired
	VehicleService vehicleService;
	
	
	@GetMapping(value = "/vehicles/{comp_type}/{id}")
	public ResponseEntity<Object> getVehicleByID(@PathVariable char comp_type, @PathVariable long id) {

		try {
			 List<?> data = vehicleService.getCompByModelID(id, comp_type);
			return ResponseHandler.apiResponse("Vehicle data", HttpStatus.OK, data);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}
	
}
