import React from "react";
import { useNavigate, Link } from "react-router-dom";

export default function Card(props) {
  let navigate = useNavigate();

  return (
    // <div className='row'>
    <div className="card_class col-sm-2 gy-3">
      <div className="card">
        <a href={"/Secondpage/" + props.id}>
          <img src={props.imgsrc} className="card-img-top" alt="image" />
        </a>

        <div className="card-body">
          <h5 className="card-title">{props.catname}</h5>
        </div>
      </div>
    </div>
    // </div>
  );
}
