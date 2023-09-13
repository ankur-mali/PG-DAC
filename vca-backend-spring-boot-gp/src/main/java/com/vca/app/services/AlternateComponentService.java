package com.vca.app.services;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vca.app.repositories.AlternateComponentRepository;


@Service
public class AlternateComponentService {
	
	@Autowired
	AlternateComponentRepository repository;

	
	public List<Map<String, Object>> findByModelIdAndCompId(int mod_id, int comp_id) {
		List<Map<String, Object>> data = repository.findByModelIdAndCompId(mod_id, comp_id);
//		List<Component> complist = new ArrayList<Component>();
//		Iterator<AlternateComponent> itr = list.listIterator();
//		
//		while(itr.hasNext()) {
//			complist.add(itr.next().getAltCompId());
//		}
		return data;
	}
}