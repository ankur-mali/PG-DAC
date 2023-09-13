package com.vca.app.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.vca.app.entity.Invoice;
import com.vca.app.services.InvoiceServiceImpl;
import com.vca.handlers.ResponseHandler;

@RestController
@CrossOrigin(origins = "*")
@RequestMapping("/api")
public class InvoiceController {

	@Autowired
	private InvoiceServiceImpl invoiceService;

	@PostMapping("/invoice")
	public ResponseEntity<?> addToCart(@RequestBody Invoice c) {
		try {
			System.out.println(c);
			invoiceService.saveCart(c);
			return ResponseHandler.apiResponse("item added in cart!", HttpStatus.OK, null);
		} catch (Exception e) {
			return ResponseHandler.apiResponse(e.getMessage(), HttpStatus.BAD_REQUEST, null);
		}
	}

}
