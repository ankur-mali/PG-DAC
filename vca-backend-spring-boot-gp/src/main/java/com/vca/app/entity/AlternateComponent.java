package com.vca.app.entity;

import java.util.Date;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.context.annotation.Configuration;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;



@Entity
@Table(name="alternate_components")
@Configuration
public class AlternateComponent 
{
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	@Column(nullable = false)
	private double deltaPrice;

	@ManyToOne(fetch = FetchType.EAGER, optional = false)
//	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "mod_id", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
//	@JsonIgnore
	private Model modId;
 
	@ManyToOne(fetch = FetchType.EAGER, optional = false)
//	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "comp_id", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
//	@JsonIgnore
	private Component compId;
	
	@ManyToOne(fetch = FetchType.EAGER, optional = false)
//	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "alt_comp_id", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
//	@JsonIgnore
	private Component altCompId;
	
    // Define 'createdAt' and 'updatedAt' fields with 'TIMESTAMP' data type
    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, updatable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private Date createdAt;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
    private Date updatedAt;
	
	public Component getAltCompId() {
		return altCompId;
	}

	public Component getCompId() {
		return compId;
	}

	public Long getId() {
		return id;
	}

	public Model getModId() {
		return modId;
	}
	
	public double getDeltaPrice() {
		return deltaPrice;
	}

	public Date getCreatedAt() {
		return createdAt;
	}

	public Date getUpdatedAt() {
		return updatedAt;
	}


}
