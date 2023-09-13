import { memo, useState } from 'react';
import './filter.scss'


interface FilterItemProps {
  data: Array<{ id: number; name?: string;}>;
  title: string;
  onItemClick: (id: number) => void;
}


const filterItem: React.FC<FilterItemProps> = ({ data, title, onItemClick }) => {

  // console.log('d',data)
  const [isOpen, setOpen] = useState(false);
  // const [items, setItem] = useState(data);
  const [selectedItem, setSelectedItem] = useState<number | null>(null);
  
  const toggleDropdown = () => setOpen(!isOpen);
  
  const handleItemClick = (id: number) => {
    setSelectedItem(prevSelectedItem => (prevSelectedItem === id ? null : id));
    console.warn(id + " "+ title)
    onItemClick(id);
  };

  return (<>

  <div className='dropdown '>
      <div className='dropdown-header' onClick={toggleDropdown}>
        {selectedItem ? data?.find(item => item.id === selectedItem)?.name : title}
        <i className={`fa fa-chevron-right icon ${isOpen && "open"}`}></i>
      </div>
      <div className={`dropdown-body ${isOpen && 'open'}`}>
        {data.length && data.map(item => (
          <div className="dropdown-item" onClick={() => handleItemClick(item.id)} key={item.id}>
            <span className={`dropdown-item-dot ${item.id === selectedItem && 'selected'}`}>• </span>
            {item.name}
          </div>
        ))}
      </div>
    </div>
  </>

  )
}

export default memo(filterItem)