import React from 'react'

export const Button2 =({setModal2}) => {
  return (
   
      <button className='btn btn-primary btn-md mx-2'
      onClick={()=>setModal2(true)}>Register</button>
    
  )
}
export default Button2;


