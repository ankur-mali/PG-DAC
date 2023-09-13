package com.vca.springjwt.repository;

import java.util.List;
import java.util.Map;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.vca.springjwt.models.User;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {
	Optional<User> findByUsername(String username);

	@Query(nativeQuery = true, value = "SELECT username, company_name, gst_number, telephone FROM users WHERE id = :user_id")
	List<Map<String, Object>> findByUserId(@Param("user_id") long user_id);

	Boolean existsByUsername(String username);

	Boolean existsByEmail(String email);
}
