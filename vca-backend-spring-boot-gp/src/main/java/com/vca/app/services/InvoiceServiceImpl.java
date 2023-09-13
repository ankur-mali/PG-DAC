package com.vca.app.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vca.app.entity.Invoice;
import com.vca.app.repositories.InvoiceRepository;

@Service
public class InvoiceServiceImpl {

	@Autowired
	private InvoiceRepository invoiceRepo;

	// Insert
	public Invoice saveCart(Invoice obj) {
		return invoiceRepo.save(obj);
	}

//	public List<Invoice> findCartByUserID(int userId) {
//		return cartRepo.findCartByUserID(userId);
//	}

}
