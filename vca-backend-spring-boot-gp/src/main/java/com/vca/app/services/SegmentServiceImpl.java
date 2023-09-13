package com.vca.app.services;

import com.vca.app.entity.Segment;
import com.vca.app.repositories.SegmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class SegmentServiceImpl implements SegmentService {

	@Autowired
	SegmentRepository segmentRepository;

	@Override
	public List<Segment> getAllSegments() {
		return segmentRepository.findAll();
	}
}
