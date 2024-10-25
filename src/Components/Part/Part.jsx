import React from 'react'
import './part.css'

export default function Part(props) {
  return (
    <section>
        <h3>{props.title}</h3>
        <div className='separator'
          style={{backgroundColor: props.color,
          boxShadow: `3px 0px 5px ${props.color}, -3px -0px 5px ${props.color}`}}>
          &nbsp;
        </div>
        <p>{props.data}</p>
    </section>
  )
}
