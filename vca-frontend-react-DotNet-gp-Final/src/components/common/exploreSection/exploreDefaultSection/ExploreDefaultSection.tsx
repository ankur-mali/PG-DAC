import "../exploreSection.scss";
import ExploreCard from "../exploreCard/ExploreCard";
import { useEffect, useState } from "react";
import axios from "axios";
import Loader from "../../loader/Loader";
import { useNavigate } from "react-router-dom";

const PAGE_NUMBER = 1;

interface CarApi {
  id: number;
  minQty: number;
  name: string;
  price: number;
  safetyRating: number;
  fuelType: string;
  imageUrl: string;
}

const ExploreDefaultSection = () => {
  let navigate = useNavigate();
  const [carsData, setCarsData] = useState<any[]>([]);
  const [page, setPage] = useState<number>(PAGE_NUMBER);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setTimeout(async () => {
          const res = await axios.get(`/models?page=${page}`, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
          });
          //console.log(res.data.data.models);
          setCarsData((prev) => [...prev, ...res.data.data.models]);
          setLoading(false);
        }, 500);
      } catch (e) {
        setLoading(false);
      }
    };

    const timerId = setTimeout(fetchData, 500);

    // Clean up the timer to avoid memory leaks
    return () => clearTimeout(timerId);
  }, [page]);

  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, []);

  const handleScroll = async () => {
    if (
      window.innerHeight + document.documentElement.scrollTop + 1 >=
      document.documentElement.scrollHeight
    ) {
      setLoading(true);
      setPage((prev) => prev + 1);
    }
  };

  return (
    <>
      <div className="max-width explore-section">
        <div className="collection-title">
          Explore fleet from multiple dealers
        </div>
        <div className="explore-grid">
          {carsData.length == 0 ? (
            <Loader />
          ) : (
            <>
              {carsData?.map((c, index) => (
                <div key={index}>
                  <ExploreCard
                    id={c.id}
                    name={c.modName}
                    price={c.price}
                    safetyRating={c.safetyRating}
                    fuelType={c.fuelType}
                    imageUrl={c.imagePath}
                    minQty={c.minQty}
                  />
                </div>
              ))}
              {loading && <Loader />}
            </>
          )}
        </div>
      </div>
    </>
  );
};

export default ExploreDefaultSection;
