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

import com.vca.app.entity.Manufacturer;
import com.vca.app.services.ManufacturerService;
import com.vca.handlers.ResponseHandler;

@RestController
@CrossOrigin(origins = "*")
@RequestMapping("/api")
public class ManufacturerController {

	@Autowired
	ManufacturerService manufacturerService;

	@GetMapping("/manufacturers/{segId}")
	public ResponseEntity<Object> getManufacturers(@PathVariable(value = "segId") Long segId) {
		try {
			List<Manufacturer> data = manufacturerService.getAllManufacturersById(segId);
			return ResponseHandler.apiResponse("Manufacturers retrieved successfully", HttpStatus.OK, data);

		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}
}
