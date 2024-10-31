import React from 'react'

//This HOC adds a default button to any component
export default function Buttoner({children}) {
  return (
    <div>
      {children}
      <button>This is the button</button>
    </div>
  )
}
