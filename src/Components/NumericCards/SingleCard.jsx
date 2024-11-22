import React from 'react'

export default function SingleCard(props) {
  return (
    <div className='single-card'>
        <p className='single-card_number'>{props.title}</p>
        <p>{props.data}</p>
    </div>
  )
}
