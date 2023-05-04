import React from 'react'

export default function CheckoutCard(props) {
  return (
    <div>
      <div className="card-container">
        <div className="card-column">
          &nbsp;
          <img src={props.img} alt="Card Image" width="170" height="170" />
        </div>
        <div className="card-column">
          <h5>{props.name}</h5>
          <p>{props.desc}</p>
          <br />
          <br />
          
        </div>
        <div className="card-column">
          <h5>₹{props.price}</h5>
        </div>
      </div>
      <b><hr/></b>
    </div>
  )
}
