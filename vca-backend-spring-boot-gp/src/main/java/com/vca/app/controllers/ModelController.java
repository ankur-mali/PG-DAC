package com.vca.app.controllers;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.entity.Model;
import com.vca.app.services.ModelService;
import com.vca.handlers.ResponseHandler;

@RestController
@CrossOrigin(origins = "*", allowedHeaders = "*")
@RequestMapping("/api")
public class ModelController {

	@Autowired
	ModelService modelService;

	// This is Paginated API
	@GetMapping("/models")
	public ResponseEntity<Object> getAllModels(@RequestParam(defaultValue = "0") int page,
			@RequestParam(defaultValue = "10") int size) {

		try {

			Pageable pageable = PageRequest.of(page, size);
			Page<Model> modelsPage = modelService.getAllModels(pageable);
			List<Model> data = modelsPage.getContent();

			Map<String, Object> response = new HashMap<>();
			response.put("models", data);
			response.put("currentPage", modelsPage.getNumber());
			response.put("totalItems", modelsPage.getTotalElements());
			response.put("totalPages", modelsPage.getTotalPages());
			return ResponseHandler.apiResponse("Models retrieved successfully", HttpStatus.OK, response);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}

	// This is Paginated API
	@GetMapping("/models/{segId}/{manuId}")
	public ResponseEntity<Object> getAllModelsByManuIdAndSegId(@PathVariable Long segId, @PathVariable Long manuId,
			@RequestParam(defaultValue = "0") int page, @RequestParam(defaultValue = "6") int size) {

		try {

			Pageable pageable = PageRequest.of(page, size);
			Page<Model> modelsPage = modelService.getAllModelsByManuIdAndSegId(manuId, segId, pageable);
			List<Model> data = modelsPage.getContent();

			Map<String, Object> response = new HashMap<>();
			response.put("models", data);
			response.put("currentPage", modelsPage.getNumber());
			response.put("totalItems", modelsPage.getTotalElements());
			response.put("totalPages", modelsPage.getTotalPages());
			return ResponseHandler.apiResponse("Models retrieved successfully", HttpStatus.OK, response);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}

	}

	// This is Paginated API
	@GetMapping("/models/{modId}")
	public ResponseEntity<Object> getModelsById(@PathVariable Long modId) {

		try {
			Model data = modelService.getModelsById(modId);

			Map<String, Object> response = new HashMap<>();
			response.put("models", data);

			return ResponseHandler.apiResponse("Model retrieved successfully", HttpStatus.OK, response);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}

}
