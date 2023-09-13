package com.vca.springjwt.payload.request;

import java.util.Set;

import com.vca.springjwt.validation.StrongPassword;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
// DTO class that represents the data you expect to receive from the signup form

public class SignupRequest {

	@NotNull(message = "Username is required!")
	@Size(min = 3, max = 20)
	private String username;

	@NotNull(message = "Email is required!")
	@Size(max = 50)
	@Email
	private String email;

	@NotNull(message = "Role is required")
	private Set<String> role;

	@StrongPassword
	private String password;

	private String companyName;
	private String addressLine1;
	private String addressLine2;
	private String city;
	private String state;
	private String pinCode;
	private String telephone;
	private String gstNumber;

	public void setPinCode(String pinCode) {
		this.pinCode = pinCode;
	}

	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}

	public void setGstNumber(String gstNumber) {
		this.gstNumber = gstNumber;
	}

	public String getUsername() {
		return username;
	}

	public String getCompanyName() {
		return companyName;
	}

	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}

	public String getAddressLine1() {
		return addressLine1;
	}

	public void setAddressLine1(String addressLine1) {
		this.addressLine1 = addressLine1;
	}

	public String getAddressLine2() {
		return addressLine2;
	}

	public void setAddressLine2(String addressLine2) {
		this.addressLine2 = addressLine2;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getState() {
		return state;
	}

	public void setState(String state) {
		this.state = state;
	}

	

	public String getPinCode() {
		return pinCode;
	}

	public String getTelephone() {
		return telephone;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Set<String> getRole() {
		return this.role;
	}

	public void setRole(Set<String> role) {
		this.role = role;
	}

	public String getGstNumber() {
		return gstNumber;
	}


}
