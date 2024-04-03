import React, { useState, useEffect } from "react";
import axios from "axios";

interface IProps {
  url: string;
  propName: string;
  children: React.ReactNode[];
}

export const ResourceLoader = (props: IProps) => {
  const [state, setState] = useState(null);

  useEffect(() => {
    (async () => {
      const response = await axios.get(props.url);
      setState(response.data);
    })();
  }, [props.url]);

  return (
    <>
      {React.Children.map(props.children, (child) => {
        if (React.isValidElement(child)) {
          return React.cloneElement(child, { [props.propName]: state });
        }
        return child;
      })}
    </>
  );
};
