import './configTabOptions.scss'

interface TabOptionsProps {
  activeTab: string;
  setActiveTab: React.Dispatch<React.SetStateAction<string>>;
}

const tabs = [
  {
    id: 1,
    name: "S",
    head1: "Standard Feature"
  },
  {
    id: 2,
    name: "C",
    head1: "Core Feature"
  },
  {
    id: 3,
    name: "I",
    head1: "Interior"
  },
  {
    id: 4,
    name: "E",
    head1: "Exterior"
  }
]

const ConfigTabOptions: React.FC<TabOptionsProps> = ({ activeTab, setActiveTab }) => {
  return (<>
    <div className='max-width'>
      <div id="tab-option-banner">

        {tabs.map((tab) => {
          return <div key={tab.id} onClick={() => setActiveTab(tab.name)} className={`tab-item absolute-center cur-po ${activeTab === tab.name && 'active-tab'}`}>
            <p className='tab-label'>{tab.head1}</p>
          </div>
        })}

      </div>
    </div>

  </>
  )
}

export default ConfigTabOptions