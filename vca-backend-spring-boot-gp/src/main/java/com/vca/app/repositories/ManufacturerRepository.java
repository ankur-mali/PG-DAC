package com.vca.app.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vca.app.entity.Manufacturer;

public interface ManufacturerRepository extends JpaRepository<Manufacturer, Long> {

	List<Manufacturer> findBySegmentId(Long segId);

}
