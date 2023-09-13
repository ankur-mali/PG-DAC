package com.vca.app.repositories;

import java.util.List;
import java.util.Map;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.vca.app.entity.Vehicle;
public interface VehicleRepository extends JpaRepository<Vehicle, Long> {

	@Query(nativeQuery = true, value = "SELECT DISTINCT(comp_id), is_configurable, comp_type, comp_name FROM vehicles JOIN components ON vehicles.comp_id = components.id JOIN models ON vehicles.mod_id = :modelId WHERE vehicles.comp_type = :comp_type")
	List<Map<String,Object>> findCompByModelId(@Param("modelId") long id, @Param("comp_type") char comp_type);
}
