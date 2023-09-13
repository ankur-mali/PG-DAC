import { useEffect, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import axios from 'axios'
import SelectComponent from '../../components/common/selectComponent/SelectComponent'

interface ModelData {
    id: number,
    image_path: string,
    minQty: number,
    modName: string,
    name: string,
    price: number,
    safetyRating: number,
    createdAt: string,
    updatedAt: string
}

interface CompDataItem {
    comp_id: number;
    comp_name: string;
    comp_type: string;
    is_configurable: string;
}

interface Props {
    comp_type: string;
}

const FeatureConfig: React.FC<Props> = ({ comp_type }) => {
    let navigate = useNavigate()
    const { id } = useParams<{ id: string }>();
    // const [modelData, setModelData] = useState<ModelData | null>(null);
    const [compData, setCompData] = useState<CompDataItem[]>([]);

    useEffect(() => {
        try {
            (async () => {
                let ress = await axios.get(`/vehicles/${comp_type}/${id}`)
                const filteredData = await ress.data.data.filter((item: CompDataItem) => item.is_configurable == 'Y');
                console.log(filteredData)
                setCompData(filteredData)
            })()
        } catch (e) {
            console.log(e)
        }

    }, [comp_type])

    return (<>
        {compData.length ?
            <>
                <div className="details-wrapper">
                    <div className="details-info">
                        <div className='details-info-body'>
                            <br />
                            <ol>
                                {compData.map((item, index) => (<>
                                    <div key={index}>
                                        <label className="label">{item.comp_name}</label>
                                        <SelectComponent comp_id={item.comp_id} model_id={id} />
                                    </div></>
                                ))}
                            </ol>
                        </div>
                    </div>
                </div>
            </>
            : <>
                No configurable Feature<br />
            </>
        }
    </>
    )
}

export default FeatureConfig


