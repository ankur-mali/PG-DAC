import './contact.scss'

const contact = () => {
  return (<>
    <div className='contact-wrapper'>
        
      <div className="contact-box max-width">
        <h2>Contact Us</h2>
        <form>
          <div className="user-box">
            <input type="text" name="" required />
            <label>Email</label>
          </div>
          <div className="user-box">
            <input type="password" name="" required />
            <label>Mobile</label>
          </div>
          <a href="#">
            <span></span>
            <span></span>
            <span></span>
            <span></span>
                    Submit
          </a>
        </form>
      </div>

        
    </div>
  </>
  )
}

export default contact