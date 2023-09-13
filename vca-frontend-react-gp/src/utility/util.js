import jwt_decode from "jwt-decode";
import html2canvas from "html2canvas";
import { jsPDF } from "jspdf";

export const authExist = () => {
  const token = localStorage.getItem("authToken");

  if (token) {
    const decoded = jwt_decode(token);
    // console.log(decoded);
    if (decoded.exp < decoded.iat) {
      return false;
    }
    return true;
  } else return false;
};

export const signout = () => {
  localStorage.removeItem("authToken");
  localStorage.removeItem("userId");
  localStorage.removeItem("userName");
  window.location.reload();
  return true;
};

export const downloadPdfDocument = () => {
  const input = document.getElementById("invoiceId");
  // Remove the element with the ID "rid"
  const ridElement = document.getElementById("rid");
  if (ridElement) {
    ridElement.remove();
  }
  html2canvas(input).then((canvas) => {
    const imgData = canvas.toDataURL("image/png");
    const pdf = new jsPDF();
    pdf.addImage(imgData, "JPEG", 0, 0);
    pdf.save("download.pdf");
  });
};

export function isIdExist(jsonArray, targetId) {
  const existingOptionsArray = jsonArray;
  const existingOptions = existingOptionsArray
    ? JSON.parse(existingOptionsArray)
    : [];

  console.log("j", existingOptions, targetId);
  for (const obj of existingOptions) {
    if (obj.selectedValue.split("@")[1] == targetId) {
      console.log(obj);
      return true;
    }
  }
  return false;
}
