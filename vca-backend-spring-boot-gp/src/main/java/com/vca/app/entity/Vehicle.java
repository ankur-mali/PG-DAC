package com.vca.app.entity;

import java.util.Date;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

enum CompType {
	S, C, I, E 
}

enum IsConfigurable {
	Y, N 
}

@Entity
@Table(name = "vehicles")
public class Vehicle {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

//	This is check constraint on this column
	@Enumerated(EnumType.STRING)
	@Column(nullable = false, length = 10)
	private CompType compType;
	
//	This is check constraint on this column
	@Enumerated(EnumType.STRING)
	@Column(nullable = false, length = 10)
	private IsConfigurable isConfigurable;
	
	@ManyToOne(fetch = FetchType.EAGER, optional = false)
//	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "mod_id", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
//	@JsonIgnore
	private Model model;

	@ManyToOne(fetch = FetchType.EAGER, optional = false)
//	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "comp_id", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
//	@JsonIgnore
	private Component component;

    // Define 'createdAt' and 'updatedAt' fields with 'TIMESTAMP' data type
    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, updatable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private Date createdAt;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
    private Date updatedAt;
    
	public Long getId() {
		return id;
	}

	public Model getModel() {
		return model;
	}

	public Component getComponent() {
		return component;
	}

	public CompType getCompType() {
		return compType;
	}

	public IsConfigurable getIsConfigurable() {
		return isConfigurable;
	}

}
