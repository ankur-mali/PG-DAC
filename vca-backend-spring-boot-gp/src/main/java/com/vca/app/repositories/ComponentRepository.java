package com.vca.app.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vca.app.entity.Component;

public interface ComponentRepository extends JpaRepository<Component, Long> {

}
