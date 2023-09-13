package com.vca.app.repositories;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import com.vca.app.entity.Model;

public interface ModelRepository extends JpaRepository<Model, Long> {

	Page<Model> findByManufacturerIdAndSegmentId(Long manuId, Long segId, Pageable pageable);
	
//	query method findAllByOrderByCreatedAtDesc
//	specifies that you want to retrieve all models and order them by the createdAt field in descending order (DESC).
    Page<Model> findAllByOrderByCreatedAtDesc(Pageable pageable);
}
