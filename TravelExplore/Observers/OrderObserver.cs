using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;

namespace TravelExplore.Observers
{
    public class OrderObserver : IObserver<OrderEntity>
    {
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable<OrderEntity> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(OrderEntity order)
        {
            var newDataInHere = order;
        }
    }
}
