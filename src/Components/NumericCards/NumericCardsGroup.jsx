import React from 'react'
import SingleCard from './SingleCard'

export default function NumericCardsGroup() {
  return (
    <div style={{display: 'flex'}}>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
    </div>
  )
}
