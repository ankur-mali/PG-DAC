package com.vca.app.services;

import java.util.List;

import com.vca.app.entity.Manufacturer;

public interface ManufacturerService {

	List<Manufacturer> getAllManufacturersById(Long id);
}
