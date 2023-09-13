package com.vca.app.entity;

import jakarta.persistence.*;

import org.hibernate.annotations.ColumnDefault;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import com.fasterxml.jackson.annotation.JsonIgnore;
import java.util.Date;

//enum FuelType {
//	PETROL, DIESEL, ELECTRIC
//}

@Entity
@Table(name = "models")
public class Model {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	// @ManyToOne(fetch = FetchType.EAGER, optional = false)
	@ManyToOne(fetch = FetchType.LAZY, optional = false)
	@JoinColumn(name = "segId", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
	@JsonIgnore
	private Segment segment;

	// @ManyToOne(fetch = FetchType.EAGER, optional = false)
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "manuId", nullable = false)
	@OnDelete(action = OnDeleteAction.CASCADE)
	@JsonIgnore
	private Manufacturer manufacturer;

	@Column(nullable = false)
	private String modName;

	@Column(nullable = false)
	private int price;

    @Column
    @ColumnDefault("5")
    private int safetyRating;

//	This is check constraint on this column
//	@Enumerated(EnumType.STRING)
//	@Column(length = 10)
//	@ColumnDefault("PETROL")
//	private FuelType fuelType;

	public String getModName() {
		return modName;
	}

	public int getSafetyRating() {
		return safetyRating;
	}

	public String getImage_path() {
		return image_path;
	}

	public int getMinQty() {
		return minQty;
	}

	public Date getCreatedAt() {
		return createdAt;
	}

	public Date getUpdatedAt() {
		return updatedAt;
	}

	@Column(nullable = false)
	private String image_path;
	
	@Column
	private int minQty;

	// Define 'createdAt' and 'updatedAt' fields with 'TIMESTAMP' data type
	@Temporal(TemporalType.TIMESTAMP)
	@Column(nullable = false, updatable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
	private Date createdAt;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(nullable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
	private Date updatedAt;

	public int getPrice() {
		return price;
	}

	public void setPrice(int price) {
		this.price = price;
	}

	public Long getId() {
		return id;
	}

	public String getName() {
		return modName;
	}

	public Segment getSegment() {
		return segment;
	}

	public Manufacturer getManufacturer() {
		return manufacturer;
	}

}
