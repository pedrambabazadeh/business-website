import React from 'react'

export default function NavBarStructure(props) {
  return (
    <ul className='nav-bar'>
        {props.items.map((item, index) => {
            return(
            <li key={index}>
                {item.name}
            </li>
            )
        })}
    </ul>
  )
}
