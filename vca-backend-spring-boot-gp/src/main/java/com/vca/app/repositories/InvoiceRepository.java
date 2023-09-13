package com.vca.app.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.vca.app.entity.Invoice;

import jakarta.transaction.Transactional;


@Repository
@Transactional
public interface InvoiceRepository extends JpaRepository<Invoice,Integer> {

//	@Query(value = "SELECT * FROM carts c WHERE c.userId = :userId", nativeQuery = true)
//    List<Invoice> findCartByUserID(@Param("userId") int userId);
//	
//	@Modifying
//	@Query(value = "UPDATE Cart c SET c.Qty = :newQty WHERE c.Cart_ID = :cartId", nativeQuery = true)
//	void UpdateQty(@Param("newQty") int QT,@Param("cartId") int cid );

}
