import { useState } from 'react';
import './carConfigure.scss'
import ConfigTabOptions from '../../components/common/configTabOptions/ConfigTabOptions';
import Navbar from '../../components/common/navbar/Navbar';
import FeatureConfig from '../carConfigTabPages/FeatureConfig';
import { useNavigate, useParams } from 'react-router-dom';

const CarConfigure = () => {

  const { id } = useParams()
  const [activeTab, setActiveTab] = useState<string>('S');
  let navigate = useNavigate()
  const getCorrectScreen = (tab: string) => {
    switch (tab) {
      case "S":
        return <FeatureConfig comp_type={"S"} />
      case "C":
        return <FeatureConfig comp_type={"C"} />
      case "I":
        return <FeatureConfig comp_type={"I"} />
      case "E":
        return <FeatureConfig comp_type={"E"} />
      default:
        return <></>
    }
  }

  return (<>
    <Navbar />
    <ConfigTabOptions activeTab={activeTab} setActiveTab={setActiveTab} />
    {getCorrectScreen(activeTab)}
    <div className="btn-panel">
      <button className='button' onClick={() => navigate(`/invoice/${id}`)}>Order Now</button>
    </div>
  </>
  )
}

export default CarConfigure