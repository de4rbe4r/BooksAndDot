import React from 'react';

const MySelect = ({children, props, onChange}) => {
    return (
        <select
            className='form-select'
            {...props}
            onChange = {onChange}
        >
            {children}
        </select>
    );
};

export default MySelect;