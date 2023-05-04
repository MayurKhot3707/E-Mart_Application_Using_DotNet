import React from "react";
import { useNavigate, Link } from "react-router-dom";

export default function Card(props) {
  let navigate = useNavigate();

  return (
    // <div className='row'>
    <div className="card_class col-sm-2 gy-3">
      <div className="card">
        <a href={"/DescPage/" + props.productid}>
          <img src={props.imgsrc} className="card-img-top" alt="image" />
        </a>

        <div className="card-body">
          <h5 className="card-title">{props.catname}</h5>
          <p>{props.shortdesc}</p>
          <p className="card-text">
            <big>
              <sup>₹</sup>
              <b>{props.price}</b>
            </big>{" "}
            <small>
              <del>{props.old_price}</del>
            </small>{" "}
            <small>({props.discount}% OFF)</small>
          </p>
        </div>
      </div>
    </div>
    // </div>
  );
}
