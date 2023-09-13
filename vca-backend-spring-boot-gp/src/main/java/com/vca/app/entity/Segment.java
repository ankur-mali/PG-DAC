package com.vca.app.entity;

import java.util.Date;

import jakarta.persistence.*;

@Entity
@Table(name = "segments")
public class Segment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(nullable = false, unique = true)
    private String segName;

    // Define 'createdAt' and 'updatedAt' fields with 'TIMESTAMP' data type
    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, updatable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private Date createdAt;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false, columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
    private Date updatedAt;
    
    public Segment() {
    }
    
    public Segment(String segName) {
        this.segName = segName;
    }

    public long getId() {
        return id;
    }

    public String getName() {
        return segName;
    }

    @Override
    public String toString() {
        return "Segment [id=" + id + ", name=" + segName + "]";
    }
}
