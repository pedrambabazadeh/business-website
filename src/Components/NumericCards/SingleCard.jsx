import React from 'react'

export default function SingleCard(props) {
  return (
    <div>
        <h2>{props.title}</h2>
        <p>{props.data}</p>
    </div>
  )
}
