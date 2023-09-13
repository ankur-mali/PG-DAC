import { useState, useEffect } from 'react'
import Footer from '../../components/common/footer/Footer'
import TabOptions from '../../components/common/tabOptions/TabOptions'
import Shop from '../shop/Shop'
import Contact from '../contact/Contact'
import Navbar from '../../components/common/navbar/Navbar'

const Home = () => {

  const [activeTab, setActiveTab] = useState<string>('Shop');
  const [mode, setMode] = useState<string>('online')

  useEffect(() => {
    sessionStorage.clear()
    const url = 'https://jsonplaceholder.typicode.com/users'
    fetch(url).then(r => {
      if (!r.ok) {
        setMode('offline')
      }
    }).catch(e=>setMode('offline'))
  }, [])

  const getCorrectScreen = (tab: string) => {
    switch (tab) {
      case "Shop":
        return <Shop />
      case "Book":
        return <Contact />
      default:
        return <Shop />
    }
  }

  return (<>
    {
      mode === 'offline' &&
      <div>
        you are in offline mode or some issue with connection
      </div>
    }
    <Navbar />
    <TabOptions activeTab={activeTab} setActiveTab={setActiveTab} />
    {getCorrectScreen(activeTab)}
    <Footer />
  </>
  )
}



export default Home