import './TabOptions.scss'
import { carSearch, carPlus } from '../../../assets/icons';

interface TabOptionsProps {
  activeTab: string;
  setActiveTab: React.Dispatch<React.SetStateAction<string>>;
}

const tabs = [
  {
    id: 1,
    name: "Shop",
    img: carSearch,
    head1: "Find a New Car"
  },
  {
    id: 2,
    name: "Book",
    img: carPlus,
    head1: "Book a Test Drive"
  },
  {
    id: 3,
    name: "Config",
    img: carSearch,
    head1: "Build Your Own"
  }
]

const TabOptions: React.FC<TabOptionsProps> = ({ activeTab, setActiveTab }) => {
  return (<>
    <div className='top-banner'>
    <h1 className="overlay-h">Vehicle Configurator</h1>
    <p className="overlay-p">Product for leasing company</p>
    </div>
    <div className='max-width'>

      <div id="tab-option-banner">

        {tabs.map((tab) => {
          return <div key={tab.id} onClick={() => setActiveTab(tab.name)} className={`tab-item absolute-center cur-po ${activeTab === tab.name && 'active-tab'}`}>
            <img src={tab.img} alt={tab.name} className='tab-image' />
            <p className='tab-label'>{tab.head1}</p>
          </div>
        })}

      </div>
    </div>

  </>
  )
}

export default TabOptions