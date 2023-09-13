//package com.vca.services;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Service;
//
//import com.vca.entity.Registration;
//import com.vca.repositories.RegistrationRepository;
//
//@Service
//public class RegitrationServiceImpl implements RegistrationService{
//	
//	@Autowired
//    private RegistrationRepository repository;
//
//	@Override
//	public Registration findByUsername(String email) {
//		// TODO Auto-generated method stub
//		return repository.findByEmail(email);
//	}
//
//	@Override
//	public Registration createRegistration(Registration reg) {
//		// TODO Auto-generated method stub
//		 return repository.save(reg);
//	}
//
//}
