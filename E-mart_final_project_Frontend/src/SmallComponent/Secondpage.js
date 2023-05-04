import React from "react";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Card from "../SmallComponent/Card";
import ProductCard from "../SmallComponent/ProductCard";

export function SecondPage(props) {
  const [products, setProduct] = useState([]);

  const { catMasterID } = useParams();
  useEffect(() => {
    fetch("https://localhost:7030/api/CatMasters/" + catMasterID)
      .then((res) => res.json())
      .then((result) => {
        setProduct(result);
        console.log(result);
      });
  }, []);

  return (
    <div>
      <br/>
      <div className="container-fluid mb-5">
        <div className="row">
          <div className="col-12 mx-auto">
          <div className="row gt-4">
            {products.map((val, ind) => {
              if (val.productID == null && val.flag == "N") {
                return (
                  <Card
                    key={ind}
                    imgsrc={val.catImagPath}
                    catname={val.catName}
                    id={val.catMasterID}
                    productid={val.productID}
                  />
                );
              } else {
                return (
                  <ProductCard
                    key={ind}
                    imgsrc={val.c.catImagPath}
                    catname={val.c.catName}
                    id={val.c.catMasterID}
                    price={val.p.price}
                    shortdesc={val.p.productShortDescription}
                    productid={val.c.productID}
                  />
                );
              }
            })}
          </div>
          </div>
        </div>
      </div>
    </div>
  );
}
