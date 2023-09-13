package com.vca.app.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "components")
public class Component
{
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	@Column(nullable = false)
	private String compName;

	public Component() {

	}

	public Long getId() {
		return id;
	}

	public String getCompName() {
		return compName;
	}

	@Override
	public String toString() {
		return "Component [id=" + id + ", compName=" + compName + "]";
	}

}
