import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

import ProductCard from "../SmallComponent/ProductCard";



export default function Searchnew() {
  const [products, setProduct] = useState([]);
  const { productname } = useParams();
  useEffect(() => {
    fetch("https://localhost:7030/api/Search?productName=" + productname)
      .then((res) => res.json())
      .then((result) => {
        setProduct(result);
        console.log(result);
      });
  }, []);
  return (
    <div>
      <br/>
      <div className="row gt-4">
      {products.map((val, ind) => {
             
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
            })}
            </div>
    </div>
  );
}
