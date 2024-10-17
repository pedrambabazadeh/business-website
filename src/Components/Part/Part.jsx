import React from 'react'

export default function Part(props) {
  return (
    <section>
        <h3>{props.title}</h3>
        <p>{props.data}</p>
    </section>
  )
}
