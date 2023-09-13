package com.vca.app.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import com.vca.app.entity.Segment;

public interface SegmentRepository extends JpaRepository<Segment, Long> {

}
