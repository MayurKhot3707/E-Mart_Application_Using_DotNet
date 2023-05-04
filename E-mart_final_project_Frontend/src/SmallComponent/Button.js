import React from 'react'

export const Button = ({ setModal1 }) => {
  return (
    <button className='btn btn-primary btn-md mx-2' onClick={() => setModal1(true)}>Login</button>
  )
}

export default Button;