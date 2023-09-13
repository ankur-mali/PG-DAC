package com.vca.app.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vca.app.repositories.VehicleRepository;

@Service
public class VehicleServiceImpl implements VehicleService {

	@Autowired
	VehicleRepository vehicleRepository;

//	Fetch only Standard components
	@Override
	public List<?> getCompByModelID(long id, char c) {
		return vehicleRepository.findCompByModelId(id, c);
	}
	
}
