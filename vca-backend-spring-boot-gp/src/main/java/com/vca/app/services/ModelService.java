package com.vca.app.services;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import com.vca.app.entity.Model;

public interface ModelService {
	Page<Model> getAllModelsByManuIdAndSegId(Long manuId, Long segId, Pageable pageable);

	Page<Model> getAllModels(Pageable pageable);
	
	Model getModelsById(long id);
}
