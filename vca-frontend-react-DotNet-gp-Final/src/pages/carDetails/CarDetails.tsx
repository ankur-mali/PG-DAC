import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import "./carDetails.scss";
import { CURRENT_BASE_URL } from "../../utility/apiConfig";
import Navbar from "../../components/common/navbar/Navbar";

interface ModelData {
  id: number;
  imagePath: string;
  minQty: number;
  modName: string;
  name: string;
  price: number;
  safetyRating: number;
  createdAt: string;
  updatedAt: string;
}

interface CompDataItem {
  id: number;
  comp_name: string;
}

const CarDetails = () => {
  let navigate = useNavigate();

  const { id } = useParams();

  const [modelData, setModelData] = useState<ModelData>();
  const [compDataS, setCompDataS] = useState<CompDataItem[]>([]);
  const [compDataC, setCompDataC] = useState<CompDataItem[]>([]);
  const [compDataI, setCompDataE] = useState<CompDataItem[]>([]);
  const [compDataE, setCompDataI] = useState<CompDataItem[]>([]);

  const [loading, setLoading] = useState(true);

  useEffect(() => {
    try {
      (async () => {
        let ress = await axios.get(`/vehicles/S/${id}`);
        let resc = await axios.get(`/vehicles/C/${id}`);
        let resi = await axios.get(`/vehicles/I/${id}`);
        let rese = await axios.get(`/vehicles/E/${id}`);
        //console.log(ress.data.data);
        setCompDataS(ress.data.data);
        setCompDataC(resc.data.data);
        setCompDataI(resi.data.data);
        setCompDataE(rese.data.data);
        //console.log(compDataS);
      })();
    } catch (e) {
      console.log(e);
    } finally {
      setLoading(false);
    }

    try {
      (async () => {
        let res = await axios.get(`/models/${id}`);
        //console.log(res.data.data.models);
        setModelData(res.data.data.models);
      })();
    } catch (e) {
      console.log(e);
    }
  }, []);

  return (
    <>
      {!loading ? (
        <>
          <Navbar />
          <div className="details-wrapper">
            <div className="details-info">
              <div className="details-info-body">
                <h5>Standard Feature</h5>
                <ol>
                  {compDataS.map((item, index) => (
                    <li key={index}>{item.comp_name}</li>
                  ))}
                </ol>
              </div>

              <div className="details-info-body">
                <h5>Core Feature</h5>
                <ol>
                  {compDataC.map((item, index) => (
                    <li key={index}>{item.comp_name}</li>
                  ))}
                </ol>
              </div>

              <div className="details-info-body">
                <h5>Interior Feature</h5>
                <ol>
                  {compDataI.map((item, index) => (
                    <li key={index}>{item.comp_name}</li>
                  ))}
                </ol>
              </div>

              <div className="details-info-body">
                <h5>Exterior Feature</h5>
                <ol>
                  {compDataE.map((item, index) => (
                    <li key={index}>{item.comp_name}</li>
                  ))}
                </ol>
              </div>
            </div>

            <div className="image-wrapper">
              <div className="image-wrapper-child">
                <h1>{modelData?.modName}</h1>
                <img
                  className="details-car-img"
                  src={`${CURRENT_BASE_URL}/${modelData?.imagePath}`}
                  alt="image"
                />
              </div>
              <p>Price: {modelData?.price}</p>
              <p>safetyRating: {modelData?.safetyRating}</p>
            </div>

            <div className="btn-panel">
              <button
                className="button"
                onClick={() => navigate(`/invoice/${id}`)}
              >
                Order Now
              </button>
              <button
                className="button"
                onClick={() => navigate(`/car-configure/${id}`)}
              >
                Modify
              </button>
            </div>
          </div>
        </>
      ) : (
        <></>
      )}
    </>
  );
};

export default CarDetails;
