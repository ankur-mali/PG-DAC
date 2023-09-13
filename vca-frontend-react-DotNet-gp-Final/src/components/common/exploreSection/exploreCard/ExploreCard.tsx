import { useNavigate } from 'react-router-dom';
import './exploreCard.scss'

interface CarItemProps {
  id: number;
  name: string;
  minQty: number;
  price: number;
  safetyRating: number;
  fuelType: string;
  imageUrl: string;
}

const ExploreCard: React.FC<CarItemProps> = ({ id, name, price, safetyRating, fuelType, minQty
  , imageUrl }) => {

  let navigate = useNavigate()


  // const handleOrderNow = (id?: number) => {

  //   const existingCartString = sessionStorage.getItem('cart');
  //   const existingCart = existingCartString ? new Set(JSON.parse(existingCartString)) : new Set();
  
  //   console.log(existingCart);
  
  //   // Add the new item to the cart
  //   existingCart.add(id);
  
  //   // Convert the set back to an array and store it in sessionStorage
  //   sessionStorage.setItem('cart', JSON.stringify(Array.from(existingCart)));
    
  // };

  return (<>
    <div className='explore-card cur-po'>
      <div className='explore-card-cover'>
        <img src={imageUrl} alt="nname" className='explore-card-image' onClick={() => { navigate(`/car-details/${id}`) }} />
        {/* <div className='fuel-type'>PETROL</div> */}
        {/* {true && <div className='pro-off'>proff</div>} */}
        {/* {true && <div className='gold-off absolute-center'></div>} */}
        <div className='discount absolute-center'>Petrol</div>
      </div>
      <div className='res-row'>
        <div className='res-name'>{name}</div>
        <div className={`res-rating ${safetyRating <= 4 ? 'res-rating-red' : 'res-rating-green'}`}><p>Safety: {safetyRating}</p></div>
      </div>

      <div className='res-row'>
        <div className='res-detail'>
          <span className='res-detail-tag'>₹ {price}</span>
          <span className='res-detail-tag'>Min Quantity: {minQty}</span>
        </div>
      </div>

      <div>
        <div className='card-separator'>
        </div>

        <div className='card-button-cover'>
          <button className='card-btn' onClick={() => navigate(`/invoice/${id}`)}>Order Now</button>
        </div>
      </div>
    </div>
  </>
  )
}

export default ExploreCard