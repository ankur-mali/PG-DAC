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

interface ExploreSectionProps {
  segId: number;
  manuId: number;
}

const ExploreSection: React.FC<ExploreSectionProps> = ({ segId, manuId }) => {
  let navigate = useNavigate();
  const [carsData, setCarsData] = useState<any[]>([]);
  const [page, setPage] = useState<number>(PAGE_NUMBER);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    setPage(1);
    // console.log("id changed", segId," ", manuId)
  }, [segId, manuId]);

  useEffect(() => {
    setTimeout(async () => {
      let res: { data: { data: { models: CarApi[] } } };

      res = await axios.get(`/models/${segId}/${manuId}?page=${page}`);
      //console.log(res.data.data.models);
      setCarsData((prev) => {
        return [...res.data.data.models, ...prev];
      });

      setLoading(false);
    }, 500);
  }, [page, manuId]);

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
                <div
                  key={index}
                  onClick={() => {
                    navigate(`/car-details/${c.id}`);
                  }}
                >
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

export default ExploreSection;
