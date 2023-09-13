package com.vca.app.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.entity.Segment;
import com.vca.app.services.SegmentService;
import com.vca.handlers.ResponseHandler;

@RestController
@CrossOrigin(origins = "*")
@RequestMapping("/api")
public class SegmentController {

	@Autowired
	SegmentService segmentService;

	@GetMapping("/segments")
//	@PreAuthorize("hasRole('USER') or hasRole('MODERATOR') or hasRole('ADMIN')")
	public ResponseEntity<Object> getAllSegments() {
		try {
			List<Segment> data = segmentService.getAllSegments();
			return ResponseHandler.apiResponse("Segments retrieved successfully", HttpStatus.OK, data);

		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}

}